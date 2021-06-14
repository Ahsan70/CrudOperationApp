using AutoMapper;
using CrudOperationUsingEF.Dtos;
using CrudOperationUsingEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudOperationUsingEF.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            

        }
    }
}