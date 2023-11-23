namespace CiphersMain.Breakers
{
    /// <summary>
    /// An object for managing the best keys found whilst breaking a cipher.
    /// </summary>
    /// <typeparam name="IKey">The type of key used.</typeparam>
    internal class BreakerResultContainer<IKey>
    {
        object _lockObj = new object();
        Queue<IKey> _keys;
        Queue<double> _fitnesses;
        Queue<string> _texts;
        int _length;
        public double BestFitness { get; private set; } = 0;
        public IKey BestKey { get => _keys.Peek(); }
        public BreakerResultContainer(int length)
        {
            _length = length;
            _keys = new Queue<IKey>(length);
            _texts = new Queue<string>(length);
            _fitnesses = new Queue<double>(length);
        }
        /// <summary>
        /// Pushes the current key to the queue if <paramref name="fitness"/> is greater than the best fitness.
        /// Thread safe.
        /// </summary>
        /// <param name="key">The key used to decipher.</param>
        /// <param name="fitness">The fitness of the text.</param>
        /// <param name="text">The currently decrypted text that was deciphered using the <paramref name="key"/></param>
        /// <returns>Whether the key was pushed or not.</returns>
        public bool TryPush(IKey key, double fitness, string text)
        {
            bool pushed = false;
            lock (_lockObj)
            {
                if (fitness > BestFitness)
                {
                    BestFitness = fitness;
                    while(_keys.Count >= _length)
                        _keys.Dequeue();
                    _keys.Enqueue(key);

                    while (_fitnesses.Count >= _length)
                        _fitnesses.Dequeue();
                    _fitnesses.Enqueue(fitness);

                    while (_texts.Count >= _length)
                        _texts.Dequeue();
                    _texts.Enqueue(text);

                    pushed = true;
                }
            }
            return pushed;
        }
        public BreakerResult<IKey> ToResult()=> new BreakerResult<IKey>(_keys.ToList(), _texts.ToList(), _fitnesses.ToList());
    }
}
