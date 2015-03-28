using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniGames.Framework.Input
{
    public interface ICharacterInput
    {
        bool CanGetCharacter();
        char GetCharacter();
        bool TryGetGharacter(out char c);
    }
}
