using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBench.Util;
using NBench;
using ProjectmanagerApp.Controllers;

namespace ProjectManagerApp.Test
{
    [ExcludeFromCodeCoverage]
   
    public class ProjectManagerAppPerformenceTest
    {
        private Counter _counter;
        private ProjectManagerController controller;
        private int TaskId;
        private int UserId;
        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            _counter = context.GetCounter("TestCounter");
            controller = new ProjectManagerController();
            TaskId = new BusinessLayer.ProjectManagerCore().GetTasks().FirstOrDefault().Task_ID;
            UserId = new BusinessLayer.ProjectManagerCore().GetUsers().FirstOrDefault().User_ID;
           
        }

        [PerfBenchmark(Description = "Get All tasks.",
       NumberOfIterations = 500, RunMode = RunMode.Throughput,
       RunTimeMilliseconds = 1000, TestMode = TestMode.Measurement)]
        [CounterMeasurement("TestCounter")]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.ThirtyTwoKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        public void Getask()
        {
            // Act on Test  

            controller.GetTasks();
            _counter.Increment();
        }

        [PerfBenchmark(Description = "Get All Projects.",
       NumberOfIterations = 500, RunMode = RunMode.Throughput,
       RunTimeMilliseconds = 1000, TestMode = TestMode.Measurement)]
        [CounterMeasurement("TestCounter")]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.ThirtyTwoKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        public void GetProjects()
        {
            // Act on Test  

            controller.GetProject();
            _counter.Increment();
        }

        [PerfBenchmark(Description = "Get All Users.",
      NumberOfIterations = 500, RunMode = RunMode.Throughput,
      RunTimeMilliseconds = 1000, TestMode = TestMode.Measurement)]
        [CounterMeasurement("TestCounter")]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.ThirtyTwoKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        public void GetUsers()
        {
            // Act on Test  

            controller.GetUser();
            _counter.Increment();
        }

        [PerfBenchmark(Description = "Get specific task.",
     NumberOfIterations = 500, RunMode = RunMode.Throughput,
     RunTimeMilliseconds = 1000, TestMode = TestMode.Measurement)]
        [CounterMeasurement("TestCounter")]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.ThirtyTwoKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        public void GetSpecificTask()
        {
            // Act on Test  

            controller.GetSpecificTask(TaskId);
            _counter.Increment();
        }

        [PerfBenchmark(Description = "Get specific user.",
     NumberOfIterations = 500, RunMode = RunMode.Throughput,
     RunTimeMilliseconds = 1000, TestMode = TestMode.Measurement)]
        [CounterMeasurement("TestCounter")]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.ThirtyTwoKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        public void GetSpecificProject()
        {
            // Act on Test  

            controller.GetUser(UserId);
            _counter.Increment();
        }

        [PerfCleanup]
        public void Cleanup()
        {
            // does nothing
        }

    }
    
}
