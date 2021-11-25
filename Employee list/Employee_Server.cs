using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employee_list
{
    public interface Employee_Server
    {
        [Get("/users")]
        Task<Employee[]> GetTodoItems();

        [Get("/users/{id}")]
        Task<Employee> GetTodoItem(int id);
    }
}
