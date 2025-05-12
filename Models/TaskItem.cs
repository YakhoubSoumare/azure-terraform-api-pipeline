using System.ComponentModel.DataAnnotations;

namespace TaskManagerApi.Models;

public class TaskItem{
    public long Id {get; set;}
    [Required]
    public string Title {get; set;} = null!;
    [Required]
    public string? RequestTeam{get; set;} = null;
    [Required]
    public string? ReceivingTeam{get; set;} = null;
    [Required]
    public string Status {get; set;}  = "Pending";
    public string? ReviewMessage {get; set;}
    public bool IsApproved {get; set;} = false;
}