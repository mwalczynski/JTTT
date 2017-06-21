using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using JTTT.DaoModels;
using JTTT.Dtos;
using JTTT.Repository;
using JTTT.ViewModels;

namespace JTTT.Services
{
    public class JtttTaskService
    {
        private readonly Repository<JtttTask> repository = new Repository<JtttTask>();
        private readonly Repository<JtttAction> actionRepository = new Repository<JtttAction>();
        private readonly Repository<JtttCondition> conditionsRepository = new Repository<JtttCondition>();

        public List<TaskViewModel> GetAllTasks()
        {
            var jtttTasks = repository.FindAll(x => x.Action, x => x.Condition);
            var dtos = jtttTasks.Select(jtttTask => Mapper.Map<TaskDto>(jtttTask)).ToList();
            var viewModels = dtos.Select(dto => Mapper.Map<TaskViewModel>(dto)).ToList();        
            return viewModels;
        }

        public void AddNewTask(TaskDto taskDto)
        {
            var taskDao = Mapper.Map<JtttTask>(taskDto);
            repository.Add(taskDao);
        }

        public void DeleteTask(TaskDto taskDto)
        {
            var taskDao = Mapper.Map<JtttTask>(taskDto);
            var id = repository.GetId(taskDao);
        }

        public void DeleteAll()
        {
            var jtttTasks = repository.FindAll();
            foreach (var task in jtttTasks)
            {
                repository.Delete(task.Id);
                actionRepository.Delete(task.ActionId);
                conditionsRepository.Delete(task.ConditionId);
            }
        }
    }
}
