using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using AutoMapper;
using GalaSoft.MvvmLight.CommandWpf;
using JTTT.Dtos;
using JTTT.Services;
using JTTT.ViewModels.BaseViewModels;
using JTTT.ViewModels.IfThisViewModels;
using JTTT.ViewModels.ThenThatViewModels;
using MimeKit;

namespace JTTT.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            ActCommand = new RelayCommand(Act, CanAct);
            CleanCommand = new RelayCommand(Clean, CanClean);
            DeSerializeCommand = new RelayCommand(DeSerialize);
            SerializeCommand = new RelayCommand(Serialize);
            AddTaskCommand = new RelayCommand(AddTask, CanAddTask);
            NewTaskCommand = new RelayCommand(NewTask, IsCurrentTaskListed);
            RemoveTaskCommand = new RelayCommand(RemoveTask, IsCurrentTaskListed);
        }

        private readonly JtttTaskService service = new JtttTaskService();

        private ObservableCollection<TaskViewModel> tasks;
        public ObservableCollection<TaskViewModel> Tasks
        {
            get
            {
                if (tasks == null)
                    LoadTasks();

                return tasks;
            }
            set
            {
                tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }

        private TaskViewModel currentTask;
        public TaskViewModel CurrentTask
        {
            get
            {
                if (currentTask == null)
                    NewTask();

                return currentTask;
            }
            set
            {
                currentTask = value;
                OnPropertyChanged(nameof(CurrentTask));
            }
        }

        public ICommand ActCommand { get; }
        public ICommand CleanCommand { get; }
        public ICommand DeSerializeCommand { get; }
        public ICommand SerializeCommand { get; }
        public ICommand AddTaskCommand { get; }
        public ICommand NewTaskCommand { get; }
        public ICommand RemoveTaskCommand { get; }

        private void LoadTasks()
        {
            Tasks = new ObservableCollection<TaskViewModel>();

            var tasksFromRepository = service.GetAllTasks();
            foreach (var task in tasksFromRepository)
            {
                AddTask(task);
            }
            ActualizeTasksIds();
        }

        private void Act()
        {
            foreach (var task in Tasks)
            {
                task.Act();
            }
        }

        private bool CanAct()
        {
            foreach (var task in Tasks)
            {
                if (!task.IsValid())
                    return false;
            }
            return Tasks.Any();
        }

        private void Clean()
        {
            service.DeleteAll();
            Tasks.Clear();
        }

        private bool CanClean()
        {
            return Tasks.Any();
        }

        private void DeSerialize()
        {
            Tasks.Clear();

            var taskDtos = Serializer.ReadFromJsonFile<List<TaskDto>>();
            
            var taskViewModels = taskDtos.Select(task => Mapper.Map<TaskViewModel>(task)).ToList();
            foreach (var task in taskViewModels)
            {
                AddTask(task);
            }
            Tasks = new ObservableCollection<TaskViewModel>(taskViewModels);

            ActualizeTasksIds();
        }

        private void Serialize()
        {
            var tasksDtos = Tasks.Select(task => Mapper.Map<TaskDto>(task)).ToList();
            Serializer.WriteToJsonFile(tasksDtos);
        }

        private void AddTask()
        {
            AddTask(CurrentTask);
            CurrentTask = new TaskViewModel();
        }

        private void AddTask(TaskViewModel taskViewModel)
        {
            var taskDto = Mapper.Map<TaskDto>(taskViewModel);
            taskViewModel.DbId = service.AddNewTask(taskDto);

            taskDto.Id = Tasks.Count + 1;
            Tasks.Add(taskViewModel);
        }

        private bool CanAddTask()
        {
            return CurrentTask.IsValid() && !IsCurrentTaskListed();
        }

        private void NewTask()
        {
            CurrentTask = new TaskViewModel();
        }

        private void RemoveTask()
        {
            service.DeleteTask(CurrentTask.DbId);

            Tasks.Remove(CurrentTask);
            ActualizeTasksIds();
            CurrentTask = new TaskViewModel();
        }

        private void ActualizeTasksIds()
        {
            for (int i = 0; i < Tasks.Count; i++)
            {
                Tasks[i].Id = i + 1;
            }
        }

        private bool IsCurrentTaskListed()
        {
            return !CurrentTask.IsNew;
        }

    }
}
