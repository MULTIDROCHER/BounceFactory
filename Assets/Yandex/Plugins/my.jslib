mergeInto(LibraryManager.library, {

  Hello: function () {
    console.log("________________________" + player.getName()+ "________________________");
    console.log(player.getPhoto("medium"));

    myGameInstance.SendMessage('Yandex', 'SetName', player.getName());
  },

  RateGame: function () {
    console.log("________________________RATE GAME________________________");

    ysdk.feedback.canReview()
        .then(({ value, reason }) => {
            if (value) {
                ysdk.feedback.requestReview()
                    .then(({ feedbackSent }) => {
                        console.log(feedbackSent);
                        myGameInstance.SendMessage('Yandex', 'IsRated', feedbackSent);
                    })
            } else {
                console.log(reason)
            }
        })
  },


});