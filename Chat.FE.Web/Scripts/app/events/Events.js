var app;
(function (app) {
    var events;
    (function (events) {
        var RoomsEvents = (function () {
            function RoomsEvents() {
            }
            RoomsEvents.RoomAdded = 'roomAdded';
            return RoomsEvents;
        }());
        events.RoomsEvents = RoomsEvents;
    })(events = app.events || (app.events = {}));
})(app || (app = {}));
