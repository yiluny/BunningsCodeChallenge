# Coding Skill Challenge

The coding skill challenge is implemented with ASP.Net Web Forms. By clicking "Generate Result CSV" button on the first page after running with IIS Express, a sample output will be generated based on the excel file created.

The process to generate the output results are - 
- Read the sample inputs from CatalogA, CatalogB, BarcodesA and BarcodesB CSV files in Input folder and covert the data into list of objects
- The objects then will be proccessed with LINQ query
- The result objects will be then created in a downloadable csv file

## Steps to run the solution

- Open the CodingSkills.sln file in visual studio.
- Build the solution
- Run by clicking on "IIS Express" button
- Click on "Generate Result CSV" button
- Boom!! Now you have the sample output csv file to be downloaded
