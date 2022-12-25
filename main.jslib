mergeInto(LibraryManager.library, {

    GetLanguage: function () {
        var lang = ysdk.environment.i18n.lang;
        var bufferSize = lengthBytesUTF8(lang) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(lang, buffer, bufferSize);
        return buffer;
    },

    GetLeaderBoardData: function () {
        auth().then(() => {
            ysdk.getLeaderboards()
            .then(lb => {
                lb.getLeaderboardEntries('leaderboard', { quantityTop: 10, includeUser: true })
                .then(res => {
                    console.log(JSON.stringify(res));
                    MyGameInstance.SendMessage('YandexSDK', 'GetLeaderBoardDataHandler', JSON.stringify(res));
                });
            });
        });
    },

    SetLeaderBoardValue: function (score) {
        auth().then(() => {
            ysdk.getLeaderboards()
            .then(lb => {
                var leaderBoard = lb;
                lb.setLeaderboardScore('leaderboard', score)
                .then(() => {
                    leaderBoard.getLeaderboardEntries('leaderboard', { quantityTop: 10, includeUser: true })
                    .then(res => {
                        console.log(JSON.stringify(res));
                        MyGameInstance.SendMessage('YandexSDK', 'GetLeaderBoardDataHandler', JSON.stringify(res));
                    });
                });
            });
        });
    },

});