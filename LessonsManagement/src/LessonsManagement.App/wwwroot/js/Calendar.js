function CalendarEvents() {

    var events = [];
    $.ajax({
        type: "GET",
        url: "/home/GetEventsAsync",
        success: function (data) {
            $.each(data, function (i, v) {
                events.push({
                    lessonId: v.lessonId,
                    title: v.title,
                    description: v.title,
                    start: moment(v.start),
                    end: v.end != null ? moment(v.end) : null,
                    color: v.color,
                    allDay: v.allDay
                });
            })

            GenerateCalender(events);
        },
        error: function (error) {
            alert('failed');
        }
    })

    function GenerateCalender(events) {
        $('#calender').fullCalendar('destroy');
        $('#calender').fullCalendar({
            themesystem: 'jquery-ui',
            contentHeight: 400,
            defaultDate: new Date(),
            timeFormat: 'h(:mm)a',
            height: 400,
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,basicWeek,basicDay,agenda,listMonth'
            },
            eventLimit: false,
            //eventColor: '#378006',
            events: events,
            eventClick: function (calEvent, jsEvent, view) {
                clickEventCalendar(calEvent, jsEvent, view);
            }
        })
    }


    function clickEventCalendar(calEvent, jsEvent, view) {
        $('#myModal #eventTitle').text(calEvent.title);
        var $description = $('<div/>');
        $description.append($('<p/>').html('<b>Start:</b>' + calEvent.start.format("DD-MMM-YYYY HH:mm a")));
        if (calEvent.end != null) {
            $description.append($('<p/>').html('<b>End:</b>' + calEvent.end.format("DD-MMM-YYYY HH:mm a")));
        }
        $description.append($('<p/>').html('<b>Description:</b>' + calEvent.description));
        $description.append($('<p/>').html('<a href="/edit-lesson/' + calEvent.lessonId + '" class="btn btn-info">Edit</a>'));
        $('#myModal #pDetails').empty().html($description);

        $('#myModal').appendTo("body").modal('show');
l
    }
}