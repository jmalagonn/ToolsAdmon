import { OutputToolState } from "./Output-tool-state.model";
import { Tool } from "./Tool.model";
import { User } from "./User.model";

export interface OutputTool {
    outputDateTime: Date;
    outputToolId: number;
    outputToolState: OutputToolState;
    responsible: User;
    Tools: Tool[];
}