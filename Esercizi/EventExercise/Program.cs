using EventExercise;

StatoEuropeo italia = new StatoEuropeo("Italia");
StatoEuropeo germania = new StatoEuropeo("Germania");
StatoEuropeo francia = new StatoEuropeo("Francia");

UnioneEuropea ue = new UnioneEuropea();

italia.AggiornamentoCovid += ue.AggiornaTotaleCovid;
germania.AggiornamentoCovid += ue.AggiornaTotaleCovid;
francia.AggiornamentoCovid += ue.AggiornaTotaleCovid;



italia.AggiornaCasiCovid(1000);
germania.AggiornaCasiCovid(800);
francia.AggiornaCasiCovid(200);


Console.WriteLine("Totale casi COVID-19 nell'Unione Europea: " + ue);