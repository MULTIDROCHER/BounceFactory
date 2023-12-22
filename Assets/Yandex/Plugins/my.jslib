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
  
  SaveExtern: function (date) {
    console.log("________________________SAVE DATA________________________");
    var dateString = JSON.UTF8ToString(date);
    var myobj = JSON.parse(dateString);
    player.setData(myobj); 
  },

  LoadExtern: function () {
    console.log("________________________LOAD DATA________________________");
    player.getData().then(_date => {
      const myJSON = JSON.stringify(_date);
      myGameInstance.SendMessage('Progress', 'Load', myJSON);
    });
  },

});