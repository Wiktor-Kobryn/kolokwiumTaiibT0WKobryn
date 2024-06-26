import { KeyboardType } from "./keyboardType.interface";

export interface KeyboardResponseDTO {
    id: number;
    model: string;
    type: KeyboardType;
}