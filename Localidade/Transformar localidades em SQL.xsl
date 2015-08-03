<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns="http://www.w3.org/TR/xhtml1/strict">

	<xsl:template match="ROOT">
		INSERT INTO localidade (nome, estado, tipo)
		VALUES
		<xsl:apply-templates/>
	</xsl:template>

	<xsl:template match="/ROOT/row">
		(
		<xsl:apply-templates/>
		),<br/>
	</xsl:template>

	<xsl:template match="/ROOT/row/field">
		<xsl:choose>
			<xsl:when test="@name='loc_no'">
				"<xsl:value-of select="."/>",
			</xsl:when>
			<xsl:when test="@name='ufe_sg'">
				(SELECT codigo FROM estado WHERE sigla LIKE '<xsl:value-of select="."/>'),
			</xsl:when>
			<xsl:when test="@name='loc_in_tipo_localidade'">
				<xsl:choose>
					<xsl:when test=".='M'">
						1
					</xsl:when>
					<xsl:when test=".='D'">
						2
					</xsl:when>
					<xsl:when test=".='P'">
						3
					</xsl:when>
					<xsl:when test=".='R'">
						4
					</xsl:when>
				</xsl:choose>
			</xsl:when>
		</xsl:choose>
	</xsl:template>

	<html>
		<xsl:apply-templates/>
	</html>
	
</xsl:stylesheet>
