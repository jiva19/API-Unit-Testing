namespace LearningProject2.Properties.CustomException;

public class InvalidIdException(string message) : Exception("InvalidIdExcpetion: " + message);