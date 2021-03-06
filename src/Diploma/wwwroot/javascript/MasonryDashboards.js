﻿var $grid = $('.grid').masonry({
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
        $.ajax({
            url: $(event.target).parent()[0].href,
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
    var span_name = document.createElement('span');//название
        span_name.className = 'spanName';
        $(span_name).append(p.Name);
    var span_link = document.createElement('span');//линк
        span_link.className = 'spanLink';
    var link = document.createElement('a');
        $(link).attr('href', '/Dashboard/Overview/' + p.Id);
        $(link).addClass('btn btn-primary');
        $(link).css('display', 'none');
        $(link).append('More..');
        $(span_link).append(link);
   // var span_delete = document.createElement('span');//удалить
    //    span_delete.className = 'spanDel';
    var link = document.createElement('a');
        
        $(link).attr('href', '/Dashboard/DeleteDashboard/' + p.Id);
       
        $(link).css('display', 'none');
    var img = document.createElement('img');
        img.className = 'spanDel';
        $(img).attr('src', '/img/delete24.png');
        $(img).attr('id', 'deleteDash');
        $(link).append(img);
        $(elem).append(link);
    //    $(span_delete).append(link);
    $(elem).append(span_name);
    $(elem).append(span_link);
 //   $(elem).append(span_delete);

    var wRand = Math.random();
    var hRand = Math.random();
    var widthClass = wRand > 0.8 ? 'grid-item--width3' : wRand > 0.6 ? 'grid-item--width2' : '';
    var heightClass = hRand > 0.85 ? 'grid-item--height4' : hRand > 0.6 ? 'grid-item--height3' : hRand > 0.35 ? 'grid-item--height2' : '';
    elem.className = 'grid-item ' + widthClass + ' ' + heightClass;
    return elem;
}

$('#create_dashboard').submit(function (event) {
    var req = {
        Name: $('#Name').val()
    };
    if (req.Name != '') {
        console.log(req);
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

