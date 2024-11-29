﻿namespace Cafe.Application.Common.DTOs.Feedbacks;

public class ShortFeedbackDto
{
    public DateTime Date { get; set; }

    public int Rating { get; set; }

    public string? Description { get; set; }

    public string UserName { get; set; }
}