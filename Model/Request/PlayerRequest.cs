using Checkers.Model;

namespace Checkers.Model.Request
{
    public class PlayerRequest
    {
        public Input MovementInput { get; set; }
        public Board Board { get; set; }
    }
}
