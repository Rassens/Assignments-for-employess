using AutoMapper;
using FINAL.Data.Entities;
using FINAL.Models;

namespace FINAL.Data
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Assignment, AssignmentModel>().ReverseMap();

            CreateMap<Project, ProjectModel>().ReverseMap();

            CreateMap<Employee, EmployeeModel>().ReverseMap().ForMember(t => t.Assignments, options => options.Ignore());
            
            CreateMap<Assignment, AssignmentModel2>();
        }
    }
}
