mergeInto(LibraryManager.library, {

  Hello: function () {
    console.log("________________________" + player.getName()+ "________________________");
    console.log(player.getPhoto("medium"));
  },
});