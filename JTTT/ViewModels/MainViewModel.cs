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
                    Title = "Testowe modele",
                    IfThisPage = new TestIfThisViewModel()
                    {
                        TestValue = "Testowy warunek"
                    },
                    ThenThatPage = new TestThenThatViewModel()
                    {
                        TestValue = "Wartość do zmiany po wykonaniu"
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
            Tasks.Clear();
            var deserializedTasks = Serializer.ReadFromJsonFile<List<TaskViewModel>>();
            foreach (var deserializedTask in deserializedTasks)
            {
                var task = new TaskViewModel(deserializedTask.IfThisPage, deserializedTask.ThenThatPage); 
                Tasks.Add(task);
            }


            //            var deserializedTasks = Serializer.ReadFromJsonFile<List<TaskViewModel>>();

            //            foreach (var deserializedTask in deserializedTasks)
            //            {
            //                IfThisViewModel ifThis;
            //                ThenThatViewModel thenThat;
            //
            //                var typeOfContidion = deserializedTask.IfThisPage.TypeOfCondition;          
            //                if (typeOfContidion == typeof(IsImageViewModel))
            //                {
            //                    ifThis = deserializedTask.IfThisPage as IsImageViewModel;
            //                }
            //                else //if (typeOfContidion == typeof(TestIfThisViewModel))
            //                {
            //                    ifThis = deserializedTask.IfThisPage as TestIfThisViewModel;
            //                }
            //
            //                var typeOfAction = deserializedTask.ThenThatPage.TypeOfAction;
            //                if (typeOfAction == typeof(SendMailViewModel))
            //                {
            //                    thenThat = deserializedTask.ThenThatPage as SendMailViewModel;
            //                }
            //                else //if (typeOfAction == typeof(TestThenThatViewModel))
            //                {
            //                    thenThat = deserializedTask.ThenThatPage as TestThenThatViewModel;
            //                }
            //
            //                var task = new TaskViewModel(ifThis, thenThat) {Title = deserializedTask.Title};
            //                Tasks.Add(task);
            //            }

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
