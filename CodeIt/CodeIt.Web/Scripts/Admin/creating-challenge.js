$(function () {
    $('#tracks-list').on('change', function (ev) {
        var trackId = $(this).val();
        $.ajax({
            method: "Get",
            url: `/Api/Category/ByTrackId/${trackId}`,
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                var $categoriesList = $('#categories-list');
                for (var item of result) {
                    var $categoryOption = $('<option />')
                        .attr('value', item.Id)
                        .text(item.Category);
                    $categoriesList.append($categoryOption);
                }
            },
            error: function (err) {
                console.log('Error');
            }
        });
    })

    $('#myModal').on('shown.bs.modal', function () {
        $('#myInput').focus();
    })

    $('#save-test').on('click', function () {
        //var isSampleTestCheckValue = $('#test-modal-issample').is(":checked");
        var inputTestValue = $('#test-modal-input').val();
        var outputTestValue = $('#test-modal-output').val();

        createTest(null , inputTestValue, outputTestValue);
    })

    function createTest(_, input, output) {
        var $testsContainer = $('#tests-container');
        var id = $testsContainer.children('.challenge-test').length;

        if (!id) {
            id = 0;
        }

        var $challengeTest = $('<div />').addClass('challenge-test').attr('id', id).text(`Test ${id}`).addClass('form-control');
        //var $testIsSampleElement = $('<input />').attr('name', `Challenge.Tests[${id}].IsSample`).attr('type', 'checkbox').attr('checked', isSample).addClass('hidden').appendTo($challengeTest);
        var $testInputElement = $('<input />').attr('name', `Challenge.Tests[${id}].Input`).attr('value', input).addClass('hidden').appendTo($challengeTest);
        var $testInputElement = $('<input />').attr('name', `Challenge.Tests[${id}].Output`).attr('value', output).addClass('hidden').appendTo($challengeTest);

        //var $removeTestBtn = $('<button />')
        //    .text("Remove")
        //    .addClass('btn')
        //    .addClass('btn-danger')
        //    .addClass('btn-sm')
        //    .on('click', function () {
        //        $(this).parent().remove();
        //    })
        //    .appendTo($challengeTest);

        $testsContainer.append($challengeTest);
    }
});