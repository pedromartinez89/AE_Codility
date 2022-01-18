using System;
using System.Collections.Generic;
using Task3_StringMap.Models;


namespace Task3_StringMap.Models    
{
    // Do not change the name of this class
    public class StringMap<TValue> : IStringMap<TValue>
        where TValue : class
    {

        private Dictionary<String, TValue> _elements;

        public StringMap()
        {
            _elements = new Dictionary<String, TValue>();                
        }

        public void SetDefaultValue(TValue value)
        {
            DefaultValue = value;
        }
        

        /// <summary> Returns number of elements in a map</summary>
        public int Count
        {
            get
            {
                return _elements.Count;
            }
           
        }

        /// <summary>
        /// If <c>GetValue</c> method is called but a given key is not in a map then <c>DefaultValue</c> is returned.
        /// </summary>
        // Do not change this property
        public TValue DefaultValue { get; set; }

        /// <summary>
        /// Adds a given key and value to a map.
        /// If the given key already exists in a map, then the value associated with this key should be overriden.
        /// </summary>
        /// <returns>true if the value for the key was overriden otherwise false</returns>
        /// <exception cref="System.ArgumentNullException">If the key is null</exception>
        /// <exception cref="System.ArgumentException">If the key is an empty string</exception>
        /// <exception cref="System.ArgumentNullException">If the value is null</exception>
        public bool AddElement(string key, TValue value)
        {
            if (key is null || value is null)
            {
                throw new ArgumentNullException();
            }

            if (key == string.Empty)
            {
                throw new ArgumentException();
            }

            try
            {
                _elements.Add(key, value);
                return true;
            }
            catch (ArgumentException)
            {
                _elements.Remove(key);
                _elements.Add(key, value);
                return true;
            }
            

             
            
            
        }

        /// <summary>
        /// Removes a given key and associated value from a map.
        /// </summary>
        /// <returns>true if the key was in the map and was removed otherwise false</returns>
        /// <exception cref="System.ArgumentNullException">If the key is null</exception>
        /// <exception cref="System.ArgumentException">If the key is an empty string</exception>
        public bool RemoveElement(string key)
        {
            if (key is null)
            {
                throw new ArgumentNullException();
            }

            if (key == string.Empty)
            {
                throw new ArgumentException();
            }
            _elements.Remove(key);
            return true;
        }

        /// <summary>
        /// Returns the value associated with a given key.
        /// </summary>
        /// <returns>The value associated with a given key or <c>DefaultValue</c> if the key does not exist in a map</returns>
        /// <exception cref="System.ArgumentNullException">If a key is null</exception>
        /// <exception cref="System.ArgumentException">If a key is an empty string</exception>
        public TValue GetValue(string key)
        {            

            if (key is null)
            {
                throw new ArgumentNullException();
            }

            if (key == string.Empty)
            {
                throw new ArgumentException();
            }

            try
            {
                var result = _elements[key];
                return result;
            }
            catch (KeyNotFoundException)
            {
                return DefaultValue;
            }               
        }
    }

     
}
 
 