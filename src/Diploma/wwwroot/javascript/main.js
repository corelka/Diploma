$(document).ready(function () {
    PopUpHide();
    /*$('#datetimepicker1').datepicker();({
        language: 'en',
        pick12HourFormat: true
    });*/
    /*$("#create_event").submit(function (e) {
        e.preventDefault();

    });*/
    $('#create_event_sub').click(function () {
        $.ajax({
            url: "/CalendarEvent/CreateEvent",
            type: "POST",
            contentType: 'application/json',
            data: $('#create_event').serialize(),
            success: function (data) {
                if (data.StatusCode != 200) {
                    alert('fail!');
                }
                else alert('success');
            },
            fail: function () {
                alert('fail!');
            }
        });
        PopUpHide();
        return false;
        //$.ajaxSubmit({
        //    url: '/CalendarEvent/CreateEvent',
        //    type: 'POST',
        //    success: function (data) {
        //        console.log($form);
        //        //$('#calendar').fullCalendar('removeEvents', event._id);
        //    }
        //});
    });
    $('.datetimepicker').datetimepicker({ language: 'ru' });
    var temp_event = {};
    $('#calendar').fullCalendar({
        height: 650,
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        eventRender: function(event, element) {
            element.append( "<span class='closeon'>X</span>" );
            element.find(".closeon").click(function () {
                var req = JSON.stringify(event,["title","start","end"]);
                console.log(req);
                $.post("/CalendarEvent/DeleteEvent", req, function (data) {
                    if (data.StatusCode != 200) {
                        alert("success!");
                        $('#calendar').fullCalendar('removeEvents', event._id);
                    }                    
                });
            });
        },
        //defaultDate: '2016-05-25',
        editable: true,
        eventLimit: true,
        events: {
            url: '/CalendarEvent/GetEvents'
        },
        eventResizeStart: function (event){
            for (var key in event) {
                temp_event[key] = event[key];
            }
        },
        eventResize: function (event, delta, revertFunc) {
            var req = {
                title: event.title,
                newStartDate: event.start.format(),
                newEndDate: event.end.format(),
                start: temp_event.start.format(),
                end: temp_event.end.format()
            };
            $.ajax({
                url: "/CalendarEvent/ChangeEvent",
                type: "POST",
                contentType: 'application/json',
                data: JSON.stringify(req),
                success: function (data) {
                    if (data.StatusCode != 200) {
                        alert('fail!');
                        revertFunc();
                    }
                    temp_event = {};
                },
                fail: function () {
                    alert('fail!');
                    temp_event = {};
                    revertFunc();
                }
            });
            //$.post("/Calendar/ChangeEvent", req, function () { });
            //alert(event.title + " end is now " + event.end.format());
            //if (!confirm("is this okay?")) {
            //    revertFunc();
            //};
            //console.log(event.end.format());
            //temp_event = null;
        },

        eventDragStart: function (event) {
            for (var key in event) {
                temp_event[key] = event[key];
            }
        },

        eventDrop: function (event, delta, revertFunc) {
            var req = {
                title: event.title,
                newStartDate: event.start.format(),
                newEndDate: event.end.format(),
                start: temp_event.start.format(),
                end: temp_event.end.format()
            };
            $.ajax({
                url: "/CalendarEvent/ChangeEvent",
                type: "POST",
                contentType: 'application/json',
                data: JSON.stringify(req),
                success: function (data) {
                    if (data.StatusCode != 200) {
                        alert('fail!');
                        revertFunc();
                    }
                    temp_event = {};
                },
                fail: function () {
                    alert('fail!');
                    temp_event = {};
                    revertFunc();
                }
            });
        }


        /*{
            title: 'All Day Event',
            start: '2016-01-01'
        },
        {
            title: 'Long Event',
            start: '2016-01-07',
            end: '2016-01-10'
        },
        {
            id: 999,
            title: 'Repeating Event',
            start: '2016-01-09T16:00:00'
        },
        {
            id: 999,
            title: 'Repeating Event',
            start: '2016-01-16T16:00:00'
        },
        {
            title: 'Conference',
            start: '2016-01-11',
            end: '2016-01-13',
            editable: false
        },
        {
            title: 'Meeting',
            start: '2016-01-12T10:30:00',
            end: '2016-01-12T12:30:00'
        },
        {
            title: 'Lunch',
            start: '2016-01-12T12:00:00'
        },
        {
            title: 'Meeting',
            start: '2016-01-12T14:30:00'
        },
        {
            title: 'Happy Hour',
            start: '2016-01-12T17:30:00'
        },
        {
            title: 'Dinner',
            start: '2016-01-12T20:00:00'
        },
        {
            title: 'Birthday Party',
            start: '2016-01-13T07:00:00'
        },
        {
            title: 'Click for Google',
            url: 'http://google.com/',
            start: '2016-01-28'
        }
    ]*/
    });
});
function PopUpShow(window,clear) {
    console.log(window);
    $(".overlay").show();
    $('#' + window).show();
    if (Boolean(clear))
    $("#" + window + " input[type='text']").val('');
}
function PopUpHide() {
    $(".overlay").hide();
    $(".popup").hide();
}
$(function () {
    $(".table").droppable({
        drop: function (event, ui) {
            var prev = $(ui.draggable).parent().attr("id");
            var next = $(this).attr("id");
            console.log(prev);
            console.log(next);
            $(ui.draggable).detach().css({ top: 0, left: 0 }).appendTo(this);
            if (prev != next)
                $.post(
                    "/Dashboard/MoveIssue",
                    {
                        tableID: $(this).attr('id').substring(2),
                        issueID: ui.draggable.attr('id').substring(2)
                    });
        }
    });

    $(".issue").draggable({
        cursor: "move",
        connectToSortablle: "ul.table",
        revert: "invalid"
    });

    $(".issue").disableSelection();

    $(".AddIssue").click(function () {
        $("#window_create").find("input[name=tableId]").attr("value", $(this).closest("ul").attr("id").substring(2));
        PopUpShow("window_create",true);
    })

    $(".issue").click(function () {
        var inp = $(this).find("p");
        $("#window_change").find("input[name=tableId]").attr("value", $(this).closest("ul").attr("id").substring(2));
        $("#window_change").find("input[name=id]").attr("value", $(this).attr("id").substring(2));
        $("#window_change").find("input[name=name]").attr("value", inp[0].textContent);
        $("#window_change").find("input[name=description]").attr("value", inp[1].textContent);
        $("#window_change").find("input[name=comments]").attr("value", inp[2].textContent);
        PopUpShow("window_change",false);
    });
});