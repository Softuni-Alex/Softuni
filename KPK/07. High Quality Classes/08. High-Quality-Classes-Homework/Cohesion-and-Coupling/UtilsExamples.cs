// ***********************************************************************
// Assembly         : Cohesion-and-Coupling
// Author           : Alex
// Created          : 01-10-2016
//
// Last Modified By : Alex
// Last Modified On : 01-12-2016
// ***********************************************************************
// <copyright file="UtilsExamples.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CohesionAndCoupling
{
    using System;

    internal class UtilsExamples
    {
        private static void Main()
        {
            Console.WriteLine(GetFile.GetFileExtension("example"));
            Console.WriteLine(GetFile.GetFileExtension("example.pdf"));
            Console.WriteLine(GetFile.GetFileExtension("example.new.pdf"));

            Console.WriteLine(GetFile.GetFileNameWithoutExtension("example"));
            Console.WriteLine(GetFile.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(GetFile.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                CalcDistance.CalculateDistanceIn2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                CalcDistance.CalculateDistanceIn3D(5, 2, -1, 3, -6, 4));

            //     Console.WriteLine("Volume = {0:f2}", Parallelepiped.CalcVolume());
            //     Console.WriteLine("Diagonal XYZ = {0:f2}", Utils.CalcDiagonalXYZ());
            //     Console.WriteLine("Diagonal XY = {0:f2}", Utils.CalcDiagonalXY());
            //     Console.WriteLine("Diagonal XZ = {0:f2}", Utils.CalcDiagonalXZ());
            //     Console.WriteLine("Diagonal YZ = {0:f2}", Utils.CalcDiagonalYZ());
        }
    }
}