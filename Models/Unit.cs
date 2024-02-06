﻿namespace API_Condominio.Models;

public class Unit
{
    public int Id { get; set; }
    public int NumberUnit { get; set; }
    public Block Block { get; set; }
    public List<Resident> Residents { get; set; }
    public bool PeopleLiving { get; set; }
    public string Observation { get; set; }
    public bool HasGarage { get; set; }

}

