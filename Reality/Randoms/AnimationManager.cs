using Microsoft.Xna.Framework;

namespace Reality
{
    internal class AnimationManager
    {
        int _numframes;
        int _numColumns;
        Vector2 _size;

        int counter;
        int activeFrames;
        int interval;

        int rowPos;
        int colPos;

        public AnimationManager(int numFrames, int numColumns, Vector2 size)
        {
            _numframes = numFrames;
            _numColumns = numColumns;
            _size = size;

            counter = 0;
            activeFrames = 0;
            interval = 30;

            rowPos = 0;
            colPos = 0;
        }

        public void Update()
        {
            counter++;
            if (counter > interval)
            {
                counter = 0;
                NextFrame();
            }
        }

        private void NextFrame()
        {
            activeFrames++;
            if (activeFrames >= _numframes)
            {
                ResetAnmiation();
            }
            if (rowPos >= _numColumns)
            {
                rowPos = 0;
                colPos++;
            }
        }

        private void ResetAnmiation()
        {
            activeFrames = 0;
            colPos = 0;
            rowPos = 0;
        }

        public Rectangle GetFrame()
        {
            var testRect = new Rectangle(colPos * (int)_size.X, rowPos * (int)_size.Y, (int)_size.X, (int)_size.Y);
            var test2 = new Rectangle(20, 0, (int)_size.X, (int)_size.Y);
            return test2;
        }
    }
}
