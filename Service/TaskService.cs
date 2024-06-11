using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFToDoList.Data;
using WPFToDoList.Model;

namespace WPFToDoList.Service
{
    public class TaskService
    {
        public TaskDatatAccess taskDataAccess = new TaskDatatAccess();
        /// <summary>
        /// 查询离线模式任务数据
        /// </summary>
        /// <param name="optionType"></param>
        /// <returns></returns>
        public List<TaskModel> GetTaskData(OptionType optionType)
        {
            return taskDataAccess.GetTaskData(optionType);
        }
    }
}
