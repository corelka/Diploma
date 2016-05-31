var $grid = $('.grid').masonry({
    itemSelector: '.grid-item',
    columnWidth: 160
});

$grid.on('click', '.grid-item', function (event) {
    if ((event.target.nodeName!='A')&&(event.target.id != 'addDashboard')) {
        $(this).toggleClass('grid-item--gigante');
        $(this).find('a').toggle();
        $grid.masonry('layout');
    }
    if (event.target.id == 'deleteDash') {
        event.preventDefault();
        console.log(event.target.href);
        $.ajax({
            url: event.target.href,
            type: "POST",
            contentType: "application/json",
            success: function (data) {
                if (data != null) 
                {
                    PopUpHide();
                    $grid.masonry('remove', $(event.target.closest('div'))).masonry('layout');
                }               
            },
            fail: function () {
                //not needed for now;
            }
        });
    }
});

function CreateMasonry(p) {
    var items = [];
    p.forEach(function (item) {
        items.push(getItemElement(item));
    });
    $grid.append($(items)).masonry('appended', $(items));
};

function getItemElement(p) {
    var elem = document.createElement('div');
    var span_name = document.createElement('span');
        span_name.className = 'spanName';
        $(span_name).append(p.Name);
    var span_link = document.createElement('span');
        span_link.className = 'spanLink';
    var link = document.createElement('a');
        $(link).attr('href', '/Dashboard/Overview/' + p.Id);
        $(link).css('display', 'none');
        $(link).append('Link!');
        $(span_link).append(link);   
    var link = document.createElement('a');
        $(link).attr('id', 'deleteDash');
        $(link).attr('href', '/Dashboard/DeleteDashboard/' + p.Id);
        $(link).css('display', 'none');
        $(link).append('Delete!');
        $(span_link).append(link);
    $(elem).append(span_name);
    $(elem).append(span_link);
    var wRand = Math.random();
    var hRand = Math.random();
    var widthClass = wRand > 0.8 ? 'grid-item--width3' : wRand > 0.6 ? 'grid-item--width2' : '';
    var heightClass = hRand > 0.85 ? 'grid-item--height4' : hRand > 0.6 ? 'grid-item--height3' : hRand > 0.35 ? 'grid-item--height2' : '';
    elem.className = 'grid-item ' + widthClass + ' ' + heightClass;
    return elem;
}

$('#create_dashboard > form').submit(function (event) {
    var req = {
        Name: $('#Name').val()
    };
    if (req.Name != '') {
        $.ajax({
            url: "/Dashboard/CreateDashboard",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(req),
            success: function (data) {
                if (data == null) {
                }
                else {
                    PopUpHide();
                    var item = getItemElement(data);
                    $grid.append($(item)).masonry('appended', $(item));
                }
            },
            fail: function () {
                //not needed for now;
            }
        });
    }
    else
        alert('empty');
    event.preventDefault();
})