$(function () {
    var editor = ace.edit("code-editor");

    $('#btnSubmitCode').on('click', function () {
        var sourceCode = editor.getValue();
        var data = {
            'SourceCode': sourceCode,
            'ChallengeId': $('#challengeId').val()
        };

        console.log(data);
        $.ajax({
            method: "Post",
            url: `/Submission/Submit`,
            contentType: 'application/json; charset=utf-8',
            data:JSON.stringify(data),
            success: function (response) {
                console.log("Yes");
                console.log(respose);
            },
            error: function (err) {
                console.log("No");
                console.log(err);
            }
        });
    });
});