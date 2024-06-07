using System;
using System.Collections.Generic;

using PoolSystemAPIWebApp.Model;

using PoolSystemAPIWebApp.DTOs;

namespace PoolSystemAPIWebApp.Mappers
{
    public static class ScheduleMapper
    {
        public static ScheduleDto ToScheduleDto(this Schedule scheduleModel)
        {
            return new ScheduleDto
            {
                ScheduleId = scheduleModel.ScheduleId,
                DayOfWeek = scheduleModel.DayOfWeek,
                StartTime = scheduleModel.StartTime,
                EndTime = scheduleModel.EndTime,
            };
        }

        public static Schedule ToSchedule(this ScheduleDto scheduleDto)
        {
            return new Schedule
            {
                DayOfWeek = scheduleDto.DayOfWeek,
                StartTime = scheduleDto.StartTime,
                EndTime = scheduleDto.EndTime,
            };
        }

        public static SchedulePostRequestDto ToPostDto(this Schedule scheduleModel)
        {
            return new SchedulePostRequestDto
            {
                DayOfWeek = scheduleModel.DayOfWeek,
                StartTime = scheduleModel.StartTime,
                EndTime = scheduleModel.EndTime,
            };
        }

        public static Schedule ToSchedule(this SchedulePostRequestDto scheduleDto)
        {
            return new Schedule
            {
                DayOfWeek = scheduleDto.DayOfWeek,
                StartTime = scheduleDto.StartTime,
                EndTime = scheduleDto.EndTime,
            };
        }

    }
}
