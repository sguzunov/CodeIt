$(function () {
    var editor = ace.edit("code-editor");

    $('#btnSubmitCode').on('click', function () {
        var sourceCode = editor.getValue();
        var data = {
            'SourceCode': sourceCode,
            'ChallengeId': $('#challengeId').val()
        };
        $.ajax({
            method: "Post",
            url: `/Challenge/Submit`,
            contentType: 'application/json; charset=utf-8',
            data:JSON.stringify(data),
            success: function (response) {
                console.log(respose);
            },
            error: function (err) {
                console.log(err);
            }
        });
    });
});