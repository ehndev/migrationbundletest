﻿namespace migrationbundle.models;

public class Workflows
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ScheduledFor { get; set; }
}