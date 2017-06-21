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

        public int AddNewTask(TaskDto taskDto)
        {
            var taskDao = Mapper.Map<JtttTask>(taskDto);
            return repository.Add(taskDao);
        }

        public void DeleteTask(int id)
        {
            var taskToDelete = repository.FindById(id);
            repository.Delete(taskToDelete.Id);
            actionRepository.Delete(taskToDelete.ActionId);
            conditionsRepository.Delete(taskToDelete.ConditionId);
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
