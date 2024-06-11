using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFToDoList.Model;
using WPFToDoList.Service;

namespace WPFToDoList.ViewModel
{
    /// <summary>
    /// ViewModel层
    /// </summary>
    public class TaskViewModel
    {
        public TaskService taskService=new TaskService();

        public List<TaskModel> GetTaskData()
        {
            return taskService.GetTaskData(Data.OptionType.offlineType);
        }

    }
}
