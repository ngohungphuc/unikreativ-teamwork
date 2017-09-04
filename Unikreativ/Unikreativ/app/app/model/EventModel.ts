export class Event {
  constructor(
    public TaskName: string,
    public AssignBy: string,
    public DateAssigned: Date,
    public Description: string
  ) {}
}
