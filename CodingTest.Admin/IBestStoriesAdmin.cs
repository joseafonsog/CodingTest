using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodingTest.Infrastructure.Dtos;
using CodingTest.Infrastructure.Dtos.Service;

namespace CodingTest.Admin
{
    public interface IBestStoriesAdmin
    {
        Task<List<BestStoriesResponseDto>> GetTop20Async();
    }
}
