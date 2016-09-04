var app;
(function (app) {
    var events;
    (function (events) {
        var RoomsEvents = (function () {
            function RoomsEvents() {
            }
            RoomsEvents.RoomAdded = 'roomAdded';
            RoomsEvents.RoomChanged = 'roomChanged';
            RoomsEvents.RoomStatusUpdated = 'roomStatusUpdated';
            return RoomsEvents;
        }());
        events.RoomsEvents = RoomsEvents;
        var UsersEvents = (function () {
            function UsersEvents() {
            }
            UsersEvents.UserLoggedIn = 'userLoggedIn';
            UsersEvents.GetUserDataRecived = 'userDataRecived';
            return UsersEvents;
        }());
        events.UsersEvents = UsersEvents;
    })(events = app.events || (app.events = {}));
})(app || (app = {}));
//# sourceMappingURL=Events.js.map