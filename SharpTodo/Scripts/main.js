$(function () {
    
    $('#addTask').click(function () {
        var name = $('#name').val();
        $.ajax({
            type: 'POST',
            url: 'api/tasks',
            data: {name: name}
        }).done(function (data) {
            appendTask(data);
        });
    });

    var appendTask = function (task) {
        var target = $('#tasks tbody');
        var row = $('<tr><td>' + task.id + '</td><td>' + task.name + '</td></tr>');
        row.appendTo(target);
    }

    $.getJSON('api/tasks')
        .done(function (data) {
            $.each(data, function (_, item) {
                appendTask(item);
            });
        });
});
