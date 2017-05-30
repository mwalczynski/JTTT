using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using JTTT.ViewModels.IfThisViewModels;
using JTTT.ViewModels.ThenThatViewModels;

namespace JTTT.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<TaskViewModel> tasks;
        private TaskViewModel currentTask;

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

        public TaskViewModel CurrentTask
        {
            get => currentTask ?? (currentTask = new TaskViewModel());
            set
            {
                if (currentTask == value)
                    return;

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

        private void LoadTasks()
        {
            Tasks = new ObservableCollection<TaskViewModel>()
            {
                new TaskViewModel()
                {
                    Id = 1,
                    Title = "Test 1",
                    IfThisPage = new IsImageViewModel()
                    {
                        Url = "http://demotywatory.pl/",
                        Text = "jak"
                    },
                    ThenThatPage = new SendMailViewModel()
                    {
                        Email = "dragonmw@wp.pl"
                    }
                },
                new TaskViewModel()
                {
                    Id = 2,
                    Title = "Test 2",
                    IfThisPage = new IsImageViewModel()
                    {
                        Url = "http://demotywatory.pl/",
                        Text = "najlepsze"
                    },
                    ThenThatPage = new SendMailViewModel()
                    {
                        Email = "dragonmw@wp.pl"
                    }
                }
            };
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
            Tasks.Clear();
            TaskViewModel.ResetId();
        }

        private bool CanClean()
        {
            return Tasks.Any();
        }

        private void DeSerialize()
        {
            Tasks = Serializer.ReadFromJsonFile<ObservableCollection<TaskViewModel>>();
            ActualizeTasksIds();
        }
        
        private void Serialize()
        {
            Serializer.WriteToJsonFile(Tasks);
        }

        private void AddTask()
        {
            CurrentTask.Id = Tasks.Count + 1;
            Tasks.Add(CurrentTask);
            CurrentTask = new TaskViewModel();
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
