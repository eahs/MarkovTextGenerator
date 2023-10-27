namespace MarkovTextGenerator;

public class Chain
{
    public Dictionary<string, List<Word>> Words { get; set; } = new();
    private Dictionary<string, int> _sums = new();
    private readonly Random _rand = new(System.Environment.TickCount);

    /// <summary>
    /// Returns a random starting word from the stored list of words
    /// This may not be the best approach.. better may be to actually store
    /// a separate list of actual sentence starting words and randomly choose from that
    /// </summary>
    /// <returns></returns>
    public string GetRandomStartingWord()
    {
        return Words.Keys.ElementAt(_rand.Next() % Words.Keys.Count);
    }

    /// <summary>
    /// Adds a sentence to the chain
    /// You can use the empty string to indicate the sentence will end
    ///
    /// For example, if sentence is "The house is on fire" you would do the following:
    ///  AddPair("The", "house")
    ///  AddPair("house", "is")
    ///  AddPair("is", "on")
    ///  AddPair("on", "fire")
    ///  AddPair("fire", "")
    /// </summary>
    /// <param name="sentence"></param>
    public void AddSentence(string? sentence)
    {
        // TODO: Break sentence up into word pairs
        // TODO: Add each word pair to the chain by calling AddPair
        // TODO: The last word of any sentence will be paired up with an empty string to show that it is the end of the sentence
    }

    // Adds a pair of words to the chain that will appear in order
    public void AddPair(string word, string word2)
    {
        if (!Words.ContainsKey(word))
        {
            _sums.Add(word, 1);
            Words.Add(word, new List<Word>());
            Words[word].Add(new Word(word2));
        }
        else
        {
            bool found = false;
            foreach (Word s in Words[word])
            {
                if (s.ToString() == word2)
                {
                    found = true;
                    s.Count++;
                    _sums[word]++;
                }
            }

            if (!found)
            {
                Words[word].Add(new Word(word2));
                _sums[word]++;
            }
        }
    }

    /// <summary>
    /// Given a word, randomly chooses the next word.  This should be done
    /// by using the list of words in the words Dictionary.  The provided
    /// code allows you to pick a word from the choices array.  Bear in mind
    /// that each word is not equally likely to occur and has their own probability
    /// of occurring.
    /// </summary>
    /// <param name="word"></param>
    /// <returns></returns>
    public string GetNextWord(string word)
    {
        if (Words.ContainsKey(word))
        {
            List<Word> choices = Words[word];
            double test = _rand.NextDouble();

            Console.WriteLine("I picked the number " + test);
        }

        return "idkbbq";
    }

    /// <summary>
    /// Generates a full randomly generated sentence based that starts with
    /// startingWord.
    /// </summary>
    /// <param name="startingWord"></param>
    /// <returns></returns>
    public string GenerateSentence(string startingWord)
    {
        return "";
    }

    /// <summary>
    /// Updates the probability of choosing a second word at random
    /// for a chain of words attached to a first word.
    /// Example: If the starting word is "The" and the only word that
    /// you ever see following it is the word "cat", then "cat" would
    /// have a probability of following "The" of 1.0.  Another scenario
    /// would involve sentences like:
    /// The cat loves milk, The cat is my friend, The dog is in the yard
    /// In this scenario with the starting word of "The":
    /// - cat would have a probability of 0.66 (appears 66% of the time)
    /// - dog would have a probability of 0.33 (appears 33% of the time)
    /// </summary>
    public void UpdateProbabilities()
    {
        foreach (string word in Words.Keys)
        {
            // Update the probabilities
            foreach (Word s in Words[word])
            {
                s.Probability = (double)s.Count / _sums[word];
            }
        }
    }
}

