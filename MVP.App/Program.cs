using System;



var model = new TicTacToeModel();
var view = new TicTacToeView();
var presenter = new TicTacToePresenter(model, view);

presenter.Run();