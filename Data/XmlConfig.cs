using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using WPFToDoList.Model;
using System.Reflection;

namespace WPFToDoList.Data
{
    public class XmlConfig
    {
        /// <summary>
        /// 从Xml中读取
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public List<TaskModel> GetDataFromXml(string fileName)
        {
            XDocument xDoc = XDocument.Load(fileName); // 替换为实际的XML文件路径
            List<TaskModel> data = new List<TaskModel>();

            // 遍历所有子节点
            foreach (var child in xDoc.XPathSelectElements("//Task"))
            {
                TaskModel taskModel = new TaskModel();
                Type classType = typeof(TaskModel);
                PropertyInfo[] myClassProperties = classType.GetProperties();
                foreach (PropertyInfo property in myClassProperties)
                {
                    string nodeValue = child.XPathSelectElement(property.Name).Value;
                    switch (property.Name)
                    {
                        case "TaskId":
                            taskModel.TaskId = nodeValue;
                            break;
                        case "TaskDescription":
                            taskModel.TaskDescription = nodeValue;
                            break;
                        case "TaskStatus":
                            taskModel.TaskStatus = nodeValue;
                            break;
                        case "TaskType":
                            taskModel.TaskType = nodeValue;
                            break;
                        case "CompletionDate":
                            taskModel.CompletionDate = nodeValue;
                            break;
                        case "EndDate":
                            taskModel.EndDate = nodeValue;
                            break;
                        case "StartDate":
                            taskModel.StartDate = nodeValue;
                            break;
                        case "IsRecurring":
                            taskModel.IsRecurring = nodeValue;
                            break;
                        case "Tags":
                            taskModel.Tags = nodeValue;
                            break;
                        default:
                            break;
                    }

                }

                foreach (var subchild in child.XPathSelectElements("SubTask"))
                {
                    Type subClassType = classType.GetNestedType("SubTaskModel", BindingFlags.Public);
                    if (subClassType != null)
                    {
                        SubTaskModel subTaskModel = new SubTaskModel();
                        // 获取SubClass的所有属性名称
                        PropertyInfo[] subClassProperties = subClassType.GetProperties();
                        foreach (PropertyInfo property in subClassProperties)
                        {
                            string nodeValue = subchild.XPathSelectElement(property.Name).Value;
                            switch (property.Name)
                            {
                                case "TaskId":
                                    subTaskModel.TaskId = nodeValue;
                                    break;
                                case "SubTaskId":
                                    subTaskModel.SubTaskId = nodeValue;
                                    break;
                                case "SubTaskDescription":
                                    subTaskModel.SubTaskDescription = nodeValue;
                                    break;
                                case "SubTaskStatus":
                                    subTaskModel.SubTaskStatus = nodeValue;
                                    break;
                                case "CompletionDate":
                                    subTaskModel.CompletionDate = nodeValue;
                                    break;
                                case "EndDate":
                                    subTaskModel.EndDate = nodeValue;
                                    break;
                                case "StartDate":
                                    subTaskModel.StartDate = nodeValue;
                                    break;
                                case "IsRecurring":
                                    subTaskModel.IsRecurring = nodeValue;
                                    break;
                                default:
                                    break;
                            }
                        }
                        taskModel.SubTasks.Add(subTaskModel);
                    }
                }
                data.Add(taskModel);
            }
            return data;
        }

    }
}
