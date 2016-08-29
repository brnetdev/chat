module app.models {
    export interface IRoom {
        Name: string;
        Description: string;
    }

    export class Room implements IRoom {
        Name: string;
        Description: string;
    }
}