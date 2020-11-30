using AnimalSpawn.Domain.NavigationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSpawn.Api.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }
        public ApiResponse(T data, Metadata meta)
        {
            Data = data;
            Meta = meta;
        }
        public T Data { get; private set; }
        public Metadata Meta { get; private set; }
    }
}
