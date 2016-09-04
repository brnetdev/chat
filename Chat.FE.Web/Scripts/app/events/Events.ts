module app.events {
    export class RoomsEvents {
        public static RoomAdded = 'roomAdded';
        public static RoomChanged = 'roomChanged';
        public static RoomStatusUpdated = 'roomStatusUpdated';
    }
    export class UsersEvents {
        public static UserLoggedIn = 'userLoggedIn';
        public static GetUserDataRecived = 'userDataRecived';
    }
}