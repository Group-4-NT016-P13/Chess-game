using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class King : Pieces
    {
        public override PieceType type => PieceType.King;
        public override Player Color { get; }

        private static readonly Direction[] dirs = new Direction[]
        {
            Direction.East,
            Direction.North,
            Direction.South,
            Direction.West,
            Direction.NorthEast,
            Direction.SouthEast,
            Direction.NorthWest,
            Direction.SouthWest
        };
        public King(Player color)
        {
            Color = color;
        }
        public override Pieces copy()
        {
            King copy = new King(Color);
            copy.Move = Move;
            return copy;
        }

        private IEnumerable<Position> MovePos(Position from, Board board)
        {
            foreach ( Direction dir in dirs)
            {
                Position to= from+ dir;
                if(!Board.Inside(to))
                {
                    continue;
                }
                if(board.Empty(to) || board[to].Color != Color)
                {
                    yield return to;
                }
            }
        }
        public override IEnumerable<Base> Get(Position from , Board board)
        {
            foreach ( Position to in MovePos(from,board))
            {
                yield return new Normal(from, to);
            }
        }

        public override bool CanCaptureKing(Position from, Board board)
        {
            return MovePos(from, board).Any(to =>
            {
                Pieces piece = board[to];
                return piece != null && piece.type == PieceType.King;
            });
        }
    }
}
