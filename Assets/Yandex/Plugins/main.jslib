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

    ShowFullScreenAdv: function (){
        ysdk.adv.showFullscreenAdv({
            callbacks: {
                onClose: function(wasShown) {
                // some action after close
                },
                onError: function(error) {
                // some action on error
                }
            }
        });
    },

    ShowRewardedVideo: function () {
        ysdk.adv.showRewardedVideo({
            callbacks: {
                onOpen: () => {
                  console.log('Video ad open.');
              },
              onRewarded: () => {
                  console.log('Rewarded!');
              },
              onClose: () => {
                  console.log('Video ad closed.');
              }, 
              onError: (e) => {
                  console.log('Error while open video ad:', e);
              }
          }
      });
    },

    ShowBannerAdv: function () {
        ysdk.adv.getBannerAdvStatus().then(({ stickyAdvIsShowing , reason }) => {
            if (stickyAdvIsShowing) {
                // реклама показывается
            } else if(reason) {
                // реклама не показывается
                console.log(reason)
            } else {
                ysdk.adv.showBannerAdv();
            }
        });
    },

});