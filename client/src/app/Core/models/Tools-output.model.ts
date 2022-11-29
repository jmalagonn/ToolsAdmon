import { Tool } from "./Tool.model";
import { User } from "./User.model";

export interface ToolsOutput {
    responsible: User;
    Tools: Tool[];
}