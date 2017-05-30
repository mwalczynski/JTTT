using System;
using System.Collections.ObjectModel;
using System.Linq;
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

                if (currentTask != null)
                    currentTask.IsCurrentTask = false;

                currentTask = value;

                if (currentTask != null)
                    currentTask.IsCurrentTask = true;

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
                    IsCurrentTask = false,
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
                    IsCurrentTask = false,
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
            TaskViewModel.ResetId();
            Tasks.Clear();
        }

        private bool CanClean()
        {
            return Tasks.Any();
        }

        private void DeSerialize()
        {
            throw new NotImplementedException();
        }

        private void Serialize()
        {
            throw new NotImplementedException();
        }

        private void AddTask()
        {
            CurrentTask.SetId();
            Tasks.Add(CurrentTask);
            CurrentTask = new TaskViewModel();
        }

        private bool CanAddTask()
        {
            return CurrentTask.IsValid();
        }

        private void NewTask()
        {
            CurrentTask = new TaskViewModel();
        }

        private void RemoveTask()
        {
            Tasks.Remove(CurrentTask);
            CurrentTask = new TaskViewModel();
        }

        private bool IsCurrentTaskListed()
        {
            return !CurrentTask.IsNew;
        }

    }
}
