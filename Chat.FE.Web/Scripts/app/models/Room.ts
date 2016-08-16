module app.models {
    export interface IRoom {
        name: string;
        description: string;
    }

    export class Room implements IRoom {
        name: string;
        description: string;
    }
}