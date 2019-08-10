﻿using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using NSubstitute;
using System.Collections;

namespace TicTacToe.Test
{
    public class WinConditionTest
    {
        [Test]
        public void Win_WhenHorizontalMatch()
        {
            int boardSize = 3;
            IGameController objectiveController = NSubstitute.Substitute.For<IGameController>();
            IBoardController boardController = NSubstitute.Substitute.For<IBoardController>();
            Board board = new Board(boardSize, objectiveController, boardController);
            Piece currentPieceTouched = board.GetPiece(0, 1);
            Assert.AreEqual(currentPieceTouched.Behaviors[0].ToString(), "TicTacToe.NormalPieceBehavior");
            IconType player1Icon = new IconType();
            IconType player2Icon = new IconType();

            board.GetPiece(0, 1).Touch(player2Icon);
            board.GetPiece(0, 0).Touch(player2Icon);
            board.GetPiece(0, 2).Touch(player2Icon);
            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), true);
            board.GetPiece(0, 1).Touch(player2Icon);
            board.GetPiece(0, 0).Touch(player1Icon);
            board.GetPiece(0, 2).Touch(player2Icon);
            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), false);
        }

        [Test]
        public void Win_WhenVerticalMatch()
        {
            int boardSize = 3;
            IGameController objectiveController = NSubstitute.Substitute.For<IGameController>();
            IBoardController boardController = NSubstitute.Substitute.For<IBoardController>();
            Board board = new Board(boardSize, objectiveController, boardController);
            Piece currentPieceTouched = board.GetPiece(2, 0);
            Assert.AreEqual(currentPieceTouched.Behaviors[0].ToString(), "TicTacToe.NormalPieceBehavior");
            IconType player1Icon = new IconType();
            IconType player2Icon = new IconType();

            board.GetPiece(0, 0).Touch(player2Icon);
            board.GetPiece(1, 0).Touch(player2Icon);
            board.GetPiece(2, 0).Touch(player2Icon);
            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), true);
            board.GetPiece(0, 0).Touch(player2Icon);
            board.GetPiece(1, 0).Touch(player1Icon);
            board.GetPiece(2, 0).Touch(player2Icon);
            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), false);
        }

        [Test]
        public void Win_WhenMainDiagonalMatch()
        {
            int boardSize = 3;
            IGameController objectiveController = NSubstitute.Substitute.For<IGameController>();
            IBoardController boardController = NSubstitute.Substitute.For<IBoardController>();
            Board board = new Board(boardSize, objectiveController, boardController);
            Piece currentPieceTouched = board.GetPiece(0, 0);
            Assert.AreEqual(currentPieceTouched.Behaviors[1].ToString(), "TicTacToe.MainDiagonalPieceBehavior");
            IconType player1Icon = new IconType();
            IconType player2Icon = new IconType();

            // main diagonal with same Icon
            board.GetPiece(0, 0).Touch(player2Icon);
            board.GetPiece(1, 1).Touch(player2Icon);
            board.GetPiece(2, 2).Touch(player2Icon);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), true);

            // main diagonal with one different element
            board.GetPiece(0, 0).Touch(player2Icon);
            board.GetPiece(1, 1).Touch(player1Icon);
            board.GetPiece(2, 2).Touch(player2Icon);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), false);

            // reset diagonal elements
            board.GetPiece(0, 0).Touch(player2Icon);
            board.GetPiece(1, 1).Touch(player1Icon);
            board.GetPiece(2, 2).Touch(player1Icon);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), false);

            // set vertical elements to be the same as currentPiece
            board.GetPiece(1, 0).Touch(player2Icon);
            board.GetPiece(2, 0).Touch(player2Icon);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), true);
        }

        [Test]
        public void Win_WhenSecondaryDiagonalMatch()
        {
            int boardSize = 3;
            IGameController objectiveController = NSubstitute.Substitute.For<IGameController>();
            IBoardController boardController = NSubstitute.Substitute.For<IBoardController>();
            Board board = new Board(boardSize, objectiveController, boardController);
            Piece currentPieceTouched = board.GetPiece(2, 0);
            Assert.AreEqual(currentPieceTouched.Behaviors[1].ToString(), "TicTacToe.SecondaryDiagonalPieceBehavior");
            IconType player1Icon = new IconType();
            IconType player2Icon = new IconType();

            // secondary diagonal with same Icon
            board.GetPiece(2, 0).Touch(player2Icon);
            board.GetPiece(1, 1).Touch(player2Icon);
            board.GetPiece(0, 2).Touch(player2Icon);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), true);

            // secondary diagonal with one different element
            board.GetPiece(2, 0).Touch(player2Icon);
            board.GetPiece(1, 1).Touch(player1Icon);
            board.GetPiece(0, 2).Touch(player2Icon);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), false);

            // reset diagonal elements
            board.GetPiece(2, 0).Touch(player2Icon);
            board.GetPiece(1, 1).Touch(player1Icon);
            board.GetPiece(0, 2).Touch(player1Icon);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), false);

            // set vertical elements to be the same as currentPiece
            board.GetPiece(1, 1).Touch(player2Icon);
            board.GetPiece(0, 2).Touch(player2Icon);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), true);
        }
    }
}
