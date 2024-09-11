﻿namespace Clean.Architecture.Application.Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string name): base($"{name} is not found") { }
    }
}
