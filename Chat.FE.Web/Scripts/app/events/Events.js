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
    })(events = app.events || (app.events = {}));
})(app || (app = {}));
//# sourceMappingURL=Events.js.map